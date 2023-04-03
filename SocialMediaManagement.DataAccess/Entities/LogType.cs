using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaManagement.DataAccess.Entities
{
	public class LogType
	{
		public int LogTypeId { get; set; }
		public string LogTypeDescription { get; set; }
		public ICollection<Log> Logs { get; set; }
	}
}
