
using System.Configuration;
using System;

    public static class AppSettings {
      
		/// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static readonly string YEAR_BOMB = ConfigurationManager.AppSettings["YEAR_BOMB"];

    
		/// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static readonly string MONTH_BOMB = ConfigurationManager.AppSettings["MONTH_BOMB"];

    
		/// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static readonly string DAY_BOMB = ConfigurationManager.AppSettings["DAY_BOMB"];

    
		/// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static readonly string HOUR_BOMB = ConfigurationManager.AppSettings["HOUR_BOMB"];

    
		/// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static readonly string MINUTE_BOMB = ConfigurationManager.AppSettings["MINUTE_BOMB"];

    
		/// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static readonly string SECOND_BOMB = ConfigurationManager.AppSettings["SECOND_BOMB"];

    
	/// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
	public static DateTime DateTimeBomb = new DateTime(int.Parse(YEAR_BOMB), int.Parse(MONTH_BOMB), int.Parse(DAY_BOMB), int.Parse(HOUR_BOMB)
		, int.Parse(MINUTE_BOMB), int.Parse(SECOND_BOMB));
    }

	
 
