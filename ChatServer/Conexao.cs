using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace ChatServer
{
    // Classe que trata as conexões, serão tantas quanto as instâncias do usuário conectado
    internal class Conexao
    {
        TcpClient tcpCliente;

        // Thread que envia informação para o cliente
        private Thread thrSender;
        private StreamReader srReceptor;
        private StreamWriter swEnviador;
        private string usuarioAtual;
        private string strResposta;

        // Toma a conexão TCP
        public Conexao(TcpClient tcpCon)
        {
            tcpCliente = tcpCon;
            // A thread aceita o cliente e espera a mensagem
            thrSender = new Thread(AceitaCliente);
            thrSender.IsBackground = true;
            thrSender.Start();
        }
        private void FechaConexao()
        {
            tcpCliente.Close();
            srReceptor.Close();
            swEnviador.Close();
        }
        private void AceitaCliente()
        {
            srReceptor = new StreamReader(tcpCliente.GetStream());
            swEnviador = new StreamWriter(tcpCliente.GetStream());

            // Lê a informação da conta do cliente
            usuarioAtual = srReceptor.ReadLine();

            // temos uma resposta do cliente
            if (usuarioAtual != "")
            {
                // Armazena o nome do usuário na hash table
                if (Servidor.htUsuarios.Contains(usuarioAtual))
                {
                    // 0 => significa não conectado
                    swEnviador.WriteLine("0|Este nome de usuário já existe.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else if (usuarioAtual == "Administrador")
                {
                    // 0 => significa não conectado
                    swEnviador.WriteLine("0|Este nome de usuário é reservado.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else
                {
                    // 1 => conectou com sucesso
                    swEnviador.WriteLine("1");
                    swEnviador.Flush();

                    // Inclui o usuário na hash table e inicia a escuta de suas mensagens
                    Servidor.IncluiUsuario(tcpCliente, usuarioAtual);
                }
            }
            else
            {
                FechaConexao();
                return;
            }
            try
            {
                // cContinuia aguardando por uma mensagem do usuário
                while ((strResposta = srReceptor.ReadLine()) != "")
                {
                    // Se for inválido, remove-o
                    if (strResposta == null)
                    {
                        Servidor.RemoveUsuario(tcpCliente);
                    }
                    else
                    {
                        // Envia mensagem para todos os outros usuários
                        Servidor.EnviarMensagem(usuarioAtual, strResposta);
                    }
                }
            }
            catch
            {
                // Se houve um problema com esse usuário, desconecta-o
                Servidor.RemoveUsuario(tcpCliente);
            }
        }
    }
}
