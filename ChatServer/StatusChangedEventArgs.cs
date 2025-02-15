using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    // Tratar argumentos p/evento StatusChanged
    public class StatusChangedEventArgs : EventArgs
    {
        // Mensagem p/descrever o evento
        private string EventMsg;

        // Propriedade retorna/define mensagem do evento
        public string EventMessage 
        {
            get { return EventMsg; }
            set {  EventMsg = value; } 
        }

        // Construtor define a mensagem do evento
        public StatusChangedEventArgs(string strEventMsg)
        {
            EventMsg = strEventMsg;
        }

    }
}
