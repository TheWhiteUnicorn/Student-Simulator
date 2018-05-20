﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stats {

	public class Stats : MonoBehaviour {
		// Основные статы
		public int hunger = Params.INIT_HUNGER;
		public int energy = Params.INIT_ENERGY;
		public float marks = Params.INIT_MARKS;
		public int popularityPoints = Params.INIT_POPULARITY_POINTS;
		public int pupularityLevel = Params.INIT_POPULARITY_LEVEL;

		// Игровые валюты
		public int money = Params.INIT_MONEY;
		public int donateMoney = Params.INIT_DONATE_MONEY;

		// Флаги выполнения активностей
		public bool visitedUniversityToday {get{return visitedUniversityToday;} private set{}}
		public bool doneLabsToday {get{return doneLabsToday;} private set{}}

		// Служебные переменные
		private int foodDecreasedToday = 0; // Используется для вычитания минимального кол-ва голода за день
		public int dayOfWeek {get{return dayOfWeek;} private set{}}

		Catalogue catalogue;
		public Stats(){
			catalogue = new Catalogue();
			visitedUniversityToday = false;
			doneLabsToday = false;
			dayOfWeek = 1;
		}

		// Вызывать при окончании дня. Производит пересчеты необходимых статов для следующего дня
		public void EndOfDay(){
			// Приминяем все ежедневные уменьшения статов
			marks -= Params.ENDOFDAY_DECREASE_MARKS;

			if(foodDecreasedToday < Params.ENDOFDAY_MIN_DECREASE_FOOD){
				hunger = hunger - (Params.ENDOFDAY_MIN_DECREASE_FOOD - foodDecreasedToday);
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
			int hungerPercent = (hunger / Params.MAX_HUNGER);
			energy = Params.ENERGY_RESTORE_MIN + (Params.ENERGY_RESTORE_FULL_FOOD - Params.ENERGY_RESTORE_MIN) * hungerPercent;

			//Считаем дни недели
			++dayOfWeek;
			if(dayOfWeek == 8){
				dayOfWeek = 1;
				EndOfWeek();
			}
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
			hunger -= Params.STUDY_HUNGER_COST;
			visitedUniversityToday = true;
		}

		// Сделать лабы. Устанавливает флаг, а очки начисляет в конце дня по его значению
		public void DoLabs(){
			energy -= Params.LABS_ENERGY_COST;
			hunger -= Params.LABS_HUNGER_COST;
			doneLabsToday = true;
		}

		public void GoToSC(){
			energy -= Params.SK_ENERGY_COST;
			hunger -= Params.SK_HUNGER_COST;
			IncreasePopularity(Params.POP_INCREASE_SC);
		}

		public void ConsumeFood(string name) // excepion: KeyNotFoundException
		{ 
			hunger += catalogue.Food[name].restores;
			money -= catalogue.Food[name].price;
		}

		public void ConsumeEnergyDrink(string name){  // excepion: KeyNotFoundException
			energy += catalogue.EnergyDrinks[name].restores;
			money -= catalogue.EnergyDrinks[name].price;
		}

		private void IncreasePopularity(int value){
			popularityPoints += value;
		}
	}
}