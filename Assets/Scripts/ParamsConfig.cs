namespace Stats {
	public struct Params {
		// ������� �������� ������
		public const int MIN_ZERO = 0;
		public const int MAX_HUNGER = 100;
		public const int MAX_ENERGY = 100;
		public const int MIN_MARKS = 2;
		public const int MAX_MARKS = 5;		
		public const int MAX_POPULARITY_LEVEL = 10;

		// ��������� �������� ������
		public const int INIT_HUNGER;
		public const int INIT_ENERGY;
		public const int INIT_MARKS;
		public const int INIT_POPULARITY_POINTS;
		public const int INIT_POPULARITY_LEVEL;
		public const int INIT_MONEY;
		public const int INIT_DONATE_MONEY;
		
		// ���������� ������, ������� �� �������� � ����� ������� ���
        public const int ENDOFDAY_DECREASE_MARKS;
        public const int ENDOFDAY_MIN_DECREASE_FOOD;
	}
}