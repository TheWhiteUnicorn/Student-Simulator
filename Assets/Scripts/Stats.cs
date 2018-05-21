using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stats {

	public class Stats : MonoBehaviour {
		// Основные статы
		public int food = Params.INIT_FOOD;
		public int energy = Params.INIT_ENERGY;
		public float marks = Params.INIT_MARKS;
		public int popularityPoints = Params.INIT_POPULARITY_POINTS;
		public int pupularityLevel = Params.INIT_POPULARITY_LEVEL;

		// Игровые валюты
		public int money = Params.INIT_MONEY;
		public int donateMoney = Params.INIT_DONATE_MONEY;

		// Флаги выполнения активностей
		public bool visitedUniversityToday;// {get{return visitedUniversityToday;} private set{}}
		public bool doneLabsToday;// {get{return doneLabsToday;} private set{}} ШОТА НИРАБОТАЕТ

		// Служебные переменные
		private int foodDecreasedToday = 0; // Используется для вычитания минимального кол-ва голода за день
		public int dayOfWeek;// {get{return dayOfWeek;} private set{}}

		Catalogue catalogue;
		public Stats(){
			catalogue = new Catalogue();
			visitedUniversityToday = false;
			doneLabsToday = false;
			dayOfWeek = 1;

			// SetBoundsToSliders();
			// UpdateAllSliders();
			// UpdateAllNumericStats();
		}

		void OnEnable()
		{
			Debug.Log("logic enabled");
			if(GlobalVariables.isStudied){
				DoLabs();
			}
			SetBoundsToSliders();
			UpdateAllSliders();
			UpdateAllNumericStats();			
		}

		// Вызывать при окончании дня. Производит пересчеты необходимых статов для следующего дня
		public void EndOfDay(){
			// Приминяем все ежедневные уменьшения статов
			marks -= Params.ENDOFDAY_DECREASE_MARKS;

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

			// Рассчет энергии на след. день
			int foodPercent = (food / Params.MAX_FOOD);
			energy = Params.ENERGY_RESTORE_MIN + ((Params.ENERGY_RESTORE_FULL_FOOD - Params.ENERGY_RESTORE_MIN) * foodPercent);

			//Считаем дни недели
			++dayOfWeek;
			if(dayOfWeek == 8){
				dayOfWeek = 1;
				EndOfWeek();
			}

			studyToggle.GetComponent<StudyingToggleHandle>().setUncheckAndUnlock();
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
			energy -= Params.STUDY_ENERGY_COST;
			food -= Params.STUDY_FOOD_COST;
			visitedUniversityToday = true;

			UpdateAllSliders();
		}

		// Сделать лабы. Устанавливает флаг, а очки начисляет в конце дня по его значению
		public void DoLabs(){
			energy -= Params.LABS_ENERGY_COST;
			food -= Params.LABS_FOOD_COST;
			doneLabsToday = true;
			UpdateAllSliders();
		}

		public void GoToSC(){
			energy -= Params.SK_ENERGY_COST;
			food -= Params.SK_FOOD_COST;
			IncreasePopularity(Params.POP_INCREASE_SC);
			UpdateAllSliders();
		}

		public void ConsumeFood(string name) // excepion: KeyNotFoundException
		{ 
			food += catalogue.Food[name].restores;
			money -= catalogue.Food[name].price;
			donateMoney -= catalogue.Food[name].donatePrice;
			UpdateAllSliders();
			UpdateAllNumericStats();
		}

		public void ConsumeEnergyDrink(string name){  // excepion: KeyNotFoundException
			energy += catalogue.EnergyDrinks[name].restores;
			money -= catalogue.EnergyDrinks[name].price;
			donateMoney -= catalogue.EnergyDrinks[name].donatePrice;
			UpdateAllSliders();
			UpdateAllNumericStats();
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
	}
}