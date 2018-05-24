using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stats {

	public class Stats : MonoBehaviour {
		// Основные статы
		public static int food = Params.INIT_FOOD;
		public static int energy = Params.INIT_ENERGY;
		public static float marks = Params.INIT_MARKS;
		public static int popularityPoints = Params.INIT_POPULARITY_POINTS;
		public static int pupularityLevel = Params.INIT_POPULARITY_LEVEL;

		// Игровые валюты
		public static int money = Params.INIT_MONEY;
		public static int donateMoney = Params.INIT_DONATE_MONEY;

		// Флаги выполнения активностей
		public static bool visitedUniversityToday = false;// {get{return visitedUniversityToday;} private set{}}
		public static bool doneLabsToday;// {get{return doneLabsToday;} private set{}} ШОТА НИРАБОТАЕТ

		// Служебные переменные
		private static int foodDecreasedToday = 0; // Используется для вычитания минимального кол-ва голода за день
		public static int dayOfWeek = 1;// {get{return dayOfWeek;} private set{}}

		Catalogue catalogue;

		void Awake()
		{
			catalogue = new Catalogue();
			
			bool firstEnter = loadAllStatsFromFile();
			bindAllSliders();
			SetBoundsToSliders();
		}

		void OnEnable()
		{
			Debug.Log("logic enabled");
			if(GlobalVariables.isStudied){
				DoLabs();
			}
			bindAllSliders();
			UpdateUniverToggle();
			UpdateAllSliders();
			UpdateAllNumericStats();
		}

		void OnApplicationQuit()
		{
			saveAllStats();
		}

		private void saveAllStats(){
			PlayerPrefs.SetInt("food", food);
			PlayerPrefs.SetInt("energy", energy);
			PlayerPrefs.SetFloat("marks", marks);
			PlayerPrefs.SetInt("popularityPoints", popularityPoints);
			PlayerPrefs.SetInt("pupularityLevel", pupularityLevel);
			PlayerPrefs.SetInt("money", money);
			PlayerPrefs.SetInt("donateMoney", donateMoney);
			PlayerPrefs.SetInt("visitedUniversityToday", Convert.ToInt32(visitedUniversityToday) );
			PlayerPrefs.SetInt("doneLabsToday", Convert.ToInt32(doneLabsToday));
			PlayerPrefs.SetInt("foodDecreasedToday", foodDecreasedToday);
			PlayerPrefs.SetInt("dayOfWeek", dayOfWeek);

			PlayerPrefs.Save();
			Debug.Log("Stats saved");
		}

		private bool loadAllStatsFromFile(){
			bool ret;
			

			food = PlayerPrefs.GetInt("food", Params.INIT_FOOD);
			energy = PlayerPrefs.GetInt("energy", Params.INIT_ENERGY);
			marks = PlayerPrefs.GetFloat("marks", Params.INIT_MARKS);
			popularityPoints = PlayerPrefs.GetInt("popularityPoints", Params.INIT_POPULARITY_POINTS);
			pupularityLevel = PlayerPrefs.GetInt("pupularityLevel", Params.INIT_POPULARITY_LEVEL);
			money = PlayerPrefs.GetInt("money", Params.INIT_MONEY);
			donateMoney = PlayerPrefs.GetInt("donateMoney", Params.INIT_DONATE_MONEY);
			visitedUniversityToday = Convert.ToBoolean(PlayerPrefs.GetInt("visitedUniversityToday", 0));
			doneLabsToday = Convert.ToBoolean(PlayerPrefs.GetInt("doneLabsToday", 0));
			foodDecreasedToday = PlayerPrefs.GetInt("foodDecreasedToday", 0);
			dayOfWeek = PlayerPrefs.GetInt("dayOfWeek", 1);

			if(PlayerPrefs.HasKey("food")){
				ret = true;
				Debug.Log("Stats loaded");
			}
			else{
				ret = false;
				Debug.Log("First enter detected");
			}
			return ret;
		}

		// Вызывать при окончании дня. Производит пересчеты необходимых статов для следующего дня
		public void EndOfDay(){
			// Приминяем все ежедневные уменьшения статов
			marks -= Params.ENDOFDAY_DECREASE_MARKS;

			// Рассчет энергии на след. день
			float foodPercent = ((float)food / (float)Params.MAX_FOOD);
			energy = Params.ENERGY_RESTORE_MIN + (int)((Params.ENERGY_RESTORE_FULL_FOOD - Params.ENERGY_RESTORE_MIN) * foodPercent);

			if(foodDecreasedToday < Params.ENDOFDAY_MIN_DECREASE_FOOD){
				food = food - (Params.ENDOFDAY_MIN_DECREASE_FOOD - foodDecreasedToday);
			}
			foodDecreasedToday = 0;

			// Применяем все ежедневные начисления статов
			if(visitedUniversityToday){
				marks += Params.MARKS_INCREASE_STUDY;
				visitedUniversityToday = false;
			}
			
			if(doneLabsToday){
				marks += Params.MARKS_INCREASE_LABS;
				doneLabsToday = false;
			}

			//Считаем дни недели
			++dayOfWeek;
			if(dayOfWeek == 8){
				dayOfWeek = 1;
				EndOfWeek();
			}

			studyToggle.isOn = false;
			UpdateAllSliders();
			UpdateAllNumericStats();
		}

		private void EndOfWeek() {
			if(marks > Params.SCHOLARSHIP_THESHOLD_MARK){
				money += Params.SCHOLARSHIP_PER_WEEK;
			}
			money += Params.POCKET_MONEY_PER_WEEK;
		}

		// Пойти в универ. Устанавливает флаг, а очки начисляет в конце дня по его значению
		public void Study(){
			if(Params.STUDY_ENERGY_COST <= energy && Params.STUDY_FOOD_COST <= food){
				energy -= Params.STUDY_ENERGY_COST;
				food -= Params.STUDY_FOOD_COST;
				visitedUniversityToday = true;

				UpdateAllSliders();
			}
		}

		// Сделать лабы. Устанавливает флаг, а очки начисляет в конце дня по его значению
		public void DoLabs(){
			if(Params.LABS_ENERGY_COST <= energy && Params.LABS_FOOD_COST <= food){
				energy -= Params.LABS_ENERGY_COST;
				food -= Params.LABS_FOOD_COST;
				doneLabsToday = true; //TODO переделать
				UpdateAllSliders();
			}
		}

		public void GoToSC(){
			if(Params.SK_ENERGY_COST <= energy && Params.SK_FOOD_COST <= food){
				energy -= Params.SK_ENERGY_COST;
				food -= Params.SK_FOOD_COST;
				IncreasePopularity(Params.POP_INCREASE_SC);
				UpdateAllSliders();
			}
		}

		public void ConsumeFood(string name) // excepion: KeyNotFoundException
		{
			if(catalogue.Food[name].price <= money && catalogue.Food[name].donatePrice <= donateMoney){
				food += catalogue.Food[name].restores;
				money -= catalogue.Food[name].price;
				donateMoney -= catalogue.Food[name].donatePrice;
			
				UpdateAllSliders();
				UpdateAllNumericStats();
			}
		}

		public void ConsumeEnergyDrink(string name){  // excepion: KeyNotFoundException
			if(catalogue.EnergyDrinks[name].price <= money && catalogue.EnergyDrinks[name].donatePrice <= donateMoney){
				energy += catalogue.EnergyDrinks[name].restores;
				money -= catalogue.EnergyDrinks[name].price;
				donateMoney -= catalogue.EnergyDrinks[name].donatePrice;

				UpdateAllSliders();
				UpdateAllNumericStats();
			}
		}

		private void IncreasePopularity(int value){
			popularityPoints += value;
			UpdateAllSliders();
		}
		
		// СЛАЙДЕРЫ
		public Slider inPanelSliderStudy;
		public Slider mainSliderEnergy;
		public Slider mainSliderFood;
		public Slider mainSliderStudy;
		public Slider mainSliderPopularity;



		void bindAllSliders(){
			// GameObject tempObject = GameObject.Find("LearningProgresSliderInMenu");
    		// if(tempObject != null){
        	// 	//If we found the object , get the Canvas component from it.
        	// 	inPanelSliderStudy = tempObject.GetComponent<Slider>();
       		// 	if(inPanelSliderStudy == null){
            // 		Debug.Log("Could not locate Slider component on " + tempObject.name);
        	// 	}
    		// }

			foreach (Slider go in Resources.FindObjectsOfTypeAll(typeof(Slider)) as Slider[]){
				switch (go.name){
					case "LearningProgresSliderInMenu":
						inPanelSliderStudy = go;
					break;
					case "EnergySlider":
						mainSliderEnergy = go;
					break;
					case "FoodSlider":
						mainSliderFood = go;
					break;
					case "LearningProgresSlider":
						mainSliderStudy = go;
					break;
					case "PopularitySlider":
						mainSliderPopularity = go;
					break;
				}
			}

			foreach (Toggle go in Resources.FindObjectsOfTypeAll(typeof(Toggle)) as Toggle[]){
				if(go.name == "UniversityToggle"){
					studyToggle = go;
				}
			}

			GameObject tempObject = GameObject.Find("QuantityMoney");
			statTextMoney = tempObject.GetComponent<Text>();

			tempObject = GameObject.Find("QuantitySnacks");
			statTextDonateMoney = tempObject.GetComponent<Text>();			 
		}

		private void UpdateAllSliders(){
			inPanelSliderStudy.value = marks;
			mainSliderEnergy.value = energy;
			mainSliderFood.value = food;
			mainSliderStudy.value = marks;
			mainSliderPopularity.value = popularityPoints;
		}

		private void SetBoundsToSliders(){
			mainSliderEnergy.minValue = Params.MIN_ZERO;
			mainSliderEnergy.maxValue = Params.MAX_ENERGY;

			mainSliderFood.minValue = Params.MIN_ZERO;
			mainSliderFood.maxValue = Params.MAX_FOOD;

			mainSliderStudy.minValue = Params.MIN_ZERO;
			mainSliderStudy.maxValue = Params.MAX_MARKS;

			inPanelSliderStudy.minValue = Params.MIN_ZERO;
			inPanelSliderStudy.maxValue = Params.MAX_MARKS;

			// mainSliderPopularity.minValue = Params.MIN;
			// mainSliderPopularity.maxValue = Params.MAX_ENERGY;


		}

		// Цифровые показатели статов
		public Text statTextMoney;
		public Text statTextDonateMoney;
		private void UpdateAllNumericStats(){
			statTextMoney.text = Convert.ToString(money);
			statTextDonateMoney.text = Convert.ToString(donateMoney);
		}

		public Toggle studyToggle;

		private void UpdateUniverToggle(){
			if(visitedUniversityToday){
				studyToggle.isOn = true;
			}
		}
	}
}