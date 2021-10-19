using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewMed.Model;

namespace NewMed.Model
{
    public partial class AuthHistory
    {
        public string isSuccessful
        {
            get
            {
                if(IsSuccessfull == true)
                {
                    return "Успешный вход";
                }
                else
                {
                    return "Отказано во входе";
                }
            }
        }

        public string Color
        {
            get
            {
                if(IsSuccessfull == true)
                {
                    return "#FF76E383";
                }
                else
                {
                    return "White";
                }
            }
        }
    }

}
