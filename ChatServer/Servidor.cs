using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ChatServer
{
    // Especifica os parametros do evento
    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);
    class Servidor
    {
        // Armazena os usuários (acesso/consulta)
        public static Hashtable htUsuarios = new Hashtable(30);
        // Armazena as conexões (acesso/consulta)
        public static Hashtable htConexoes = new Hashtable(30);

        private IPAddress enderecoIP;
        private int portaHost;
        private TcpClient tcpCliente;

        // Irá notificar o formulário quando um usuário se conecta, desconecta, envia mensagem, etc
        public static event StatusChangedEventHandler StatusChanged;
        private static StatusChangedEventArgs e;

        // Define o endereço IP para o retornado pela instanciação do objeto
        public Servidor(IPAddress endereco, int porta)
        {
            enderecoIP = endereco;
            portaHost = porta;
        }

        // Thread que trata o escutados das conexões
        private Thread thrListener;
        // Objeto TCP que escuta as conexões
        private TcpListener tlsCliente;
        // Ira dizer ao laço while para manter a monitorização das conexões
        bool ServRodando = false;
        // Inclui o usuário nas tabelas hash
        public static void IncluiUsuario(TcpClient tcpUsuario, string strUsername)
        {
            // Primeiro inclui o nome e conexão para ambas as hash tables
            Servidor.htUsuarios.Add(strUsername, tcpUsuario);
            Servidor.htConexoes.Add(tcpUsuario, strUsername);

            // Informa a nova conexão aos demais usuários
            EnviaMensagemAdmin(htConexoes[tcpUsuario] + " entrou...");
        }

        // Remove usuario
        public static void RemoveUsuario(TcpClient tcpUsuario)
        {
            // Se o usuario existir...
            if (htConexoes[tcpUsuario] != null)
            {
                //Primeiro informa aos demais
                EnviaMensagemAdmin(htConexoes[tcpUsuario] + " saiu...");

                // Remove o usuário da hash table
                Servidor.htUsuarios.Remove(Servidor.htConexoes[tcpUsuario]);
                Servidor.htConexoes.Remove(tcpUsuario);
            }
        }

        // Esse evento é chamado quando queremos disparar o evento StatusChanged
        public static void OnStatusChanged(StatusChangedEventArgs e)
        {
            StatusChangedEventHandler statusHandler = StatusChanged;

            if (statusHandler != null)
            {
                // invoca o delegate
                statusHandler(null, e);
            }
        }

        // Envia mensagens administrativas
        public static void EnviaMensagemAdmin(string Mensagem)
        {
            StreamWriter swSenderSender;

            // Exibe primeiro na aplicação
            e = new StatusChangedEventArgs("Administrador: " + Mensagem);
            OnStatusChanged(e);

            // Cria um array de clientes TCPs do tamanho do numero de clientes existentes
            TcpClient[] tcpClientes = new TcpClient[Servidor.htUsuarios.Count];
            // Copia os objetos TcpClient no Array
            Servidor.htUsuarios.Values.CopyTo(tcpClientes, 0);

            // Percorre a lista de clientes TCP
            for (int i = 0; i < tcpClientes.Length; i++)
            {
                // Tenta enviar mensagem aos clientes
                try
                {
                    // Se a mensagem estiver em branco ou a conexão for nula sai...
                    if (Mensagem.Trim() == "" || tcpClientes[i] == null)
                    {
                        continue;
                    }

                    // Envia a mensagem para o usuário attual no laço
                    swSenderSender = new StreamWriter(tcpClientes[i].GetStream());
                    swSenderSender.WriteLine("Administrador: " + Mensagem);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch
                {
                    // Caso de problemas ou usuário não existe, remove-o
                    RemoveUsuario(tcpClientes[i]);
                }
            }
        }

        // Envia mensagem, de um usuário, a todos os usuários
        public static void EnviarMensagem(string Origem, string Mensagem)
        {
            StreamWriter swSenderSender;

            // Primeiro exibe a mensagem na aplicação
            e = new StatusChangedEventArgs(Origem + " disse " + Mensagem);
            OnStatusChanged(e);

            // Cria um array de clientes TCPs do tamnho do numero de clientes existentes
            TcpClient[] tcpClientes = new TcpClient[Servidor.htUsuarios.Count];

            // Copia os objetos TcpClient no array
            Servidor.htUsuarios.Values.CopyTo(tcpClientes, 0);

            // Percorre a lista de clientes TCP
            for (int i = 0; i < tcpClientes.Length; i++)
            {
                // Tenta enviar uma mensagem para cada cliente
                try
                {
                    // Se a mensagem estiver em branco ou a conexão for nula sai...
                    if (Mensagem.Trim() == "" || tcpClientes[i] == null)
                    {
                        continue;
                    }

                    // Envia a mensagem para o usuário attual no laço
                    swSenderSender = new StreamWriter(tcpClientes[i].GetStream());
                    swSenderSender.WriteLine("Administrador: " + Mensagem);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch
                {
                    // Caso de problemas ou usuário não existe, remove-o
                    RemoveUsuario(tcpClientes[i]);
                }
            }
        }

        public void IniciaAtendimento()
        {
            try
            {
                // Pega o IP
                IPAddress ipaLocal = enderecoIP;
                int portaLocal = portaHost;

                // Cria um objeto TCP listener usando o IP do servidor e porta definidas
                tlsCliente = new TcpListener(ipaLocal, portaLocal);

                // Inicia o TCP listener e escuta as conexões
                tlsCliente.Start();

                // O laço While verifica se o servidopr esta rodando antes de checar as conexões
                ServRodando = true;

                // Inicia uma nova tread que hospeda o listener
                thrListener = new Thread(MantemAtendimento);
                thrListener.IsBackground = true;
                thrListener.Start();
            }
            catch (Exception ex)
            {

            }
        }

        private void MantemAtendimento()
        {
            // Enquanto o servidor estiver rodando
            while (ServRodando)
            {
                // Aceita uma nova conexão pendente
                tcpCliente = tlsCliente.AcceptTcpClient();
                // Cria uma nova instancia da conexão
                // Conexão newConnection = new Conexao(tcpCliente);
            }
        }
    }
}
