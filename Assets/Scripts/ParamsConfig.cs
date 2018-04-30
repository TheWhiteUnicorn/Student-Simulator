using System.Collections.Generic;

namespace Stats {
	public struct Params {
		// Крайние значения статов
		public const int MIN_ZERO = 0;
		public const int MAX_FOOD = 100;
		public const int MAX_ENERGY = 100;
		public const float MIN_MARKS = 2;
		public const float MAX_MARKS = 5;		
		public const int MAX_POPULARITY_LEVEL = 10;

		// Начальные значения статов
		public const int INIT_FOOD = 100;
		public const int INIT_ENERGY = 100;
		public const float INIT_MARKS = 4;
		public const int INIT_POPULARITY_POINTS = 0;
		public const int INIT_POPULARITY_LEVEL = 1;
		public const int INIT_MONEY = 5000;
		public const int INIT_DONATE_MONEY = 1;
		
		// Количество статов, которые мы вычитаем в конце каждого дня
        public const float ENDOFDAY_DECREASE_MARKS = 1.5f;
        public const int ENDOFDAY_MIN_DECREASE_FOOD = 25;

        // Эффекты от активностей
        // *Голод/энергия
        public const int STUDY_ENERGY_COST = 40;
        public const int STUDY_FOOD_COST = 15;
        public const int LABS_ENERGY_COST = 30;
        public const int LABS_FOOD_COST = 15;
        public const int SK_ENERGY_COST = 50;
        public const int SK_FOOD_COST = 50;
        public const int JYM_ENERGY_COST = 50;
        public const int JYM_FOOD_COST = 50;
        public const int JOB_ENERGY_COST = 50;
        public const int JOB_FOOD_COST = 50;

        // *Влияние на успевамость
        public const float MARKS_INCREASE_STUDY = 1.25f;
        public const float MARKS_INCREASE_LABS = 1.0f;

        // *Влияние на очки популярности
        public const int POP_INCREASE_SC = -1;
        public const int POP_INCREASE_SOMETHING_ELSE = -1;

        // *Восстановление энергии во время сна
        public const int ENERGY_RESTORE_MIN = 20;
        public const int ENERGY_RESTORE_FULL_FOOD = 70;

        // *Деньги
        public const int SCHOLARSHIP_PER_WEEK = 1000;
        public const int POCKET_MONEY_PER_WEEK = 2500;
        public const float SCHOLARSHIP_THESHOLD_MARK = 4.0f;

	}

    struct ConsumableProduct {
        public int price;
        public int restores;
    }

    class Catalogue {
        public Dictionary<string, ConsumableProduct> Food = new Dictionary<string, ConsumableProduct> {
            {"SmallBon", new ConsumableProduct {price = 50, restores = 10}}, 
            {"LaunchBox", new ConsumableProduct {price = 120, restores = 25}}, 
            {"DinnerCFK", new ConsumableProduct {price = 220, restores = 50}}, 
        };

        public Dictionary<string, ConsumableProduct> EnergyDrinks = new Dictionary<string, ConsumableProduct> {
            {"NesCoffee", new ConsumableProduct {price = 100, restores = 20}}, 
            {"RadDoll", new ConsumableProduct {price = 225, restores = 50}}, 
            {"GreenBull", new ConsumableProduct {price = 430, restores = 100}}, 
        };
    }
}