using System; 
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Avapi.AvapiPLUS_DM
{
    internal class AvapiResponse_PLUS_DM : IAvapiResponse_PLUS_DM
    {
        public string LastHttpRequest
        {
            get;
            internal set;

        }
        public string RawData
        {
            get;
            internal set;
        }

        public IAvapiResponse_PLUS_DM_Content Data
        {
            get;
            internal set;
        }
    }

    public class MetaData_Type_PLUS_DM
    {
        public string Symbol
        {
            internal set;
            get;
        }

        public string Indicator
        {
            internal set;
            get;
        }

        public string LastRefreshed
        {
            internal set;
            get;
        }

        public string Interval
        {
            internal set;
            get;
        }

        public string TimePeriod
        {
            internal set;
            get;
        }

        public string TimeZone
        {
            internal set;
            get;
        }

    }

    public class TechnicalIndicator_Type_PLUS_DM
    {
        public string PLUS_DM
        {
            internal set;
            get;
        }

        public string DateTime
        {
            internal set;
            get;
        }

    }

    internal class AvapiResponse_PLUS_DM_Content : IAvapiResponse_PLUS_DM_Content
    {
        internal AvapiResponse_PLUS_DM_Content()
        {
           MetaData = new MetaData_Type_PLUS_DM();
           TechnicalIndicator = new List<TechnicalIndicator_Type_PLUS_DM>();
        }

       public MetaData_Type_PLUS_DM MetaData
        {
            internal set;
            get;
        }

       public IList<TechnicalIndicator_Type_PLUS_DM> TechnicalIndicator
        {
            internal set;
            get;
        }

        public bool Error
        {
            internal set;
            get;
        }

        public string ErrorMessage
        {
            internal set;
            get;
        }
    }

	public class Impl_PLUS_DM : Int_PLUS_DM
	{
		const string s_function = "PLUS_DM";

		internal static string ApiKey
		{
			get;
			set;
		}

		internal static HttpClient RestClient
		{
			get;
			set;
		}

		internal static string AvapiUrl
		{
			get;
			set;
		}

		private static readonly Lazy<Impl_PLUS_DM> s_Impl_PLUS_DM =
			new Lazy<Impl_PLUS_DM>(() => new Impl_PLUS_DM());
		public static Impl_PLUS_DM Instance
		{
			get
			{
				return s_Impl_PLUS_DM.Value;
			}
		}
		private Impl_PLUS_DM()
		{
		}

		internal static readonly IDictionary s_PLUS_DM_interval_translation
			 = new Dictionary<Const_PLUS_DM.PLUS_DM_interval, string>()
		{
			{
				Const_PLUS_DM.PLUS_DM_interval.none,
				null
			},
			{
				Const_PLUS_DM.PLUS_DM_interval.n_1min,
				"1min"
			},
			{
				Const_PLUS_DM.PLUS_DM_interval.n_5min,
				"5min"
			},
			{
				Const_PLUS_DM.PLUS_DM_interval.n_15min,
				"15min"
			},
			{
				Const_PLUS_DM.PLUS_DM_interval.n_30min,
				"30min"
			},
			{
				Const_PLUS_DM.PLUS_DM_interval.n_60min,
				"60min"
			},
			{
				Const_PLUS_DM.PLUS_DM_interval.daily,
				"daily"
			},
			{
				Const_PLUS_DM.PLUS_DM_interval.weekly,
				"weekly"
			},
			{
				Const_PLUS_DM.PLUS_DM_interval.monthly,
				"monthly"
			}
		};

		public IAvapiResponse_PLUS_DM Query(
			string symbol,
			Const_PLUS_DM.PLUS_DM_interval interval,
			int time_period)
		{
			string current_interval = s_PLUS_DM_interval_translation[interval] as string;

			return QueryPrimitive(symbol,current_interval,time_period);
		}

		public async Task<IAvapiResponse_PLUS_DM> QueryAsync(
			string symbol,
			Const_PLUS_DM.PLUS_DM_interval interval,
			int time_period)
		{
			string current_interval = s_PLUS_DM_interval_translation[interval] as string;

			return await QueryPrimitiveAsync(symbol,current_interval,time_period);
		}


		public IAvapiResponse_PLUS_DM QueryPrimitive(
			string symbol,
			string interval,
			int time_period)
		{
			// Build Base Uri
			string queryString = AvapiUrl + "/query";

			// Build query parameters
			IDictionary<string, string> getParameters = new Dictionary<string, string>();
			getParameters.Add(new KeyValuePair<string, string>("function", s_function));
			getParameters.Add(new KeyValuePair<string, string>("apikey", ApiKey));
			getParameters.Add(new KeyValuePair<string, string>("symbol",symbol));
			getParameters.Add(new KeyValuePair<string, string>("interval",interval));
			getParameters.Add(new KeyValuePair<string, string>("time_period",time_period.ToString()));
			queryString += UrlUtility.AsQueryString(getParameters);

			// Sent the Request and get the raw data from the Response
			string response = RestClient?.
				GetAsync(queryString)?.
				Result?.
				Content?.
				ReadAsStringAsync()?.
				Result; 

			IAvapiResponse_PLUS_DM ret = new AvapiResponse_PLUS_DM
			{
				RawData = response,
				Data = ParseInternal(response),
				LastHttpRequest = queryString
			};

			return ret;
		}

		public async Task<IAvapiResponse_PLUS_DM> QueryPrimitiveAsync(
			string symbol,
			string interval,
			int time_period)
		{
			// Build Base Uri
			string queryString = AvapiUrl + "/query";

			// Build query parameters
			IDictionary<string, string> getParameters = new Dictionary<string, string>();
			getParameters.Add(new KeyValuePair<string, string>("function", s_function));
			getParameters.Add(new KeyValuePair<string, string>("apikey", ApiKey));
			getParameters.Add(new KeyValuePair<string, string>("symbol",symbol));
			getParameters.Add(new KeyValuePair<string, string>("interval",interval));
			getParameters.Add(new KeyValuePair<string, string>("time_period",time_period.ToString()));
			queryString += UrlUtility.AsQueryString(getParameters);

			string response;
			using (var result = await RestClient.GetAsync(queryString))
			{
				response = await result.Content.ReadAsStringAsync();
			}
			IAvapiResponse_PLUS_DM ret = new AvapiResponse_PLUS_DM
			{
				RawData = response,
				Data = ParseInternal(response),
				LastHttpRequest = queryString
			};

			return ret;
		}

        public static IAvapiResponse_PLUS_DM_Content ParseInternal(string jsonInput)
        {
            if (string.IsNullOrEmpty(jsonInput))
            {
                return null;
            }
            if(jsonInput == "{}")
            {
                return null;
            }

            AvapiResponse_PLUS_DM_Content ret = new AvapiResponse_PLUS_DM_Content();
            JObject jsonInputParsed = JObject.Parse(jsonInput);
            string errorMessage = (string)jsonInputParsed["Error Message"];
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ret.Error = true;
                ret.ErrorMessage = errorMessage;
            }
            else
            {
                JToken metaData = jsonInputParsed["Meta Data"];
                ret.MetaData.Symbol = (string)metaData["1: Symbol"];
                ret.MetaData.Indicator = (string)metaData["2: Indicator"];
                ret.MetaData.LastRefreshed = (string)metaData["3: Last Refreshed"];
                ret.MetaData.Interval = (string)metaData["4: Interval"];
                ret.MetaData.TimePeriod = (string)metaData["5: Time Period"];
                ret.MetaData.TimeZone = (string)metaData["6: Time Zone"];
                JEnumerable<JToken> results = jsonInputParsed["Technical Analysis: PLUS_DM"].Children();
                foreach (JToken result in results)
                {
                    TechnicalIndicator_Type_PLUS_DM technicalindicator = new TechnicalIndicator_Type_PLUS_DM
                    {
                        DateTime = ((JProperty)result).Name,
                        PLUS_DM = (string)result.First["PLUS_DM"]
                    };
                    ret.TechnicalIndicator.Add(technicalindicator);
                }
            }
            return ret;
        }
	}
}