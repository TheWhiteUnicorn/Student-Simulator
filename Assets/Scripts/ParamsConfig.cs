namespace Stats {
	public struct Params {
		// Крайние значения статов
		public const int MIN_ZERO = 0;
		public const int MAX_HUNGER = 100;
		public const int MAX_ENERGY = 100;
		public const float MIN_MARKS = 2;
		public const float MAX_MARKS = 5;		
		public const int MAX_POPULARITY_LEVEL = 10;

		// Начальные значения статов
		public const int INIT_HUNGER = 100;
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
        public const int STUDY_HUNGER_COST = 15;
        public const int LABS_ENERGY_COST = 30;
        public const int LABS_HUNGER_COST = 15;
        public const int SK_ENERGY_COST = 50;
        public const int SK_HUNGER_COST = 50;
        public const int JYM_ENERGY_COST = 50;
        public const int JYM_HUNGER_COST = 50;
        public const int JOB_ENERGY_COST = 50;
        public const int JOB_HUNGER_COST = 50;

        // *Влияние на успевамость
        public const float MARKS_INCREASE_STUDY = 1.25f;
        public const float MARKS_INCREASE_LABS = 1.0f;

        // *
        public const float 

	}
}