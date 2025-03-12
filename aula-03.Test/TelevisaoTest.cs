using aula_03;

namespace aula_03.Test;

[TestClass]
public class TelevisaoTest
{
    [TestMethod]
    public void Dado_Tamanho_21_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(21f), $"O tamanho(21) n�o � suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_81_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(81f), $"O tamanho(81) n�o � suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_25_Deve_Criar_Instancia()
    {
        const float tamanho = 25f;

        Televisao televisao = new Televisao(tamanho);
        Assert.IsInstanceOfType(televisao, typeof(Televisao));
        Assert.AreEqual(tamanho, televisao.Tamanho);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Volume_10()
    {
        const int volumePadrao = 10;

        Televisao televisao = new Televisao(25f);
        Assert.AreEqual(volumePadrao, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_11_Apos_Aumentar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AumentarVolume();
        Assert.AreEqual(11, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_09_Apos_Diminuir_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.DiminuirVolume();
        Assert.AreEqual(09, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_0_Ao_Mutar()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AlternarModoMudo();
        Assert.AreEqual(0, televisao.Volume);
    }


    [TestMethod]
    public void Deve_Restaurar_Volume_Anterior_Ao_Desmutar()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        televisao.AlternarModoMudo(); // Desmuta

        Assert.AreEqual(volumeInicial, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Estado_Correto_Com_Multiplas_Alternancias_Mudo()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo(); // Desmuta
        Assert.AreEqual(volumeInicial, televisao.Volume);

        televisao.AlternarModoMudo(); // Muta novamente
        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ignorar_Mudancas_Volume_Durante_Mudo()
    {
        Televisao televisao = new Televisao(25f);

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();
        televisao.DiminuirVolume();

        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Mudo_Ao_Tentar_Alterar_Volume()
    {public class Dispositivo
{
    public bool Mudo { get; private set; }
    public int Volume { get; private set; }

    public Dispositivo()
    {
        Mudo = false;
        Volume = 50; // Volume inicial padrão
    }

    public void SetMudo(bool estado)
    {
        Mudo = estado;
    }

    public void AlterarVolume(int novoVolume)
    {
        if (Mudo)
        {
            // Não permite alterar o volume se estiver no modo "Mudo"
            return;
        }

        // Define o volume apenas se o "mudo" estiver desativado
        Volume = Math.Clamp(novoVolume, 0, 100); // Garante que o volume esteja entre 0 e 100
    }
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();

        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo();
        Assert.AreEqual(volumeInicial, televisao.Volume);
    }


    
}

public class Dispositivo
{
    public int Canal { get; private set; } // Canal atual
    public int Volume { get; private set; } // Volume atual
    private const int CanalMinimo = 1; // Canal mínimo permitido
    private const int CanalMaximo = 999; // Canal máximo permitido

    public Dispositivo()
    {
        Canal = 1; // Canal inicial padrão
        Volume = 50; // Volume inicial padrão
    }

    // Método para alterar o canal (+ ou -)
    public void AlterarCanal(bool aumentar)
    {
        if (aumentar)
        {
            Canal = (Canal < CanalMaximo) ? Canal + 1 : CanalMinimo; // Vai para o próximo canal ou reinicia no canal mínimo
        }
        else
        {
            Canal = (Canal > CanalMinimo) ? Canal - 1 : CanalMaximo; // Vai para o canal anterior ou reinicia no máximo
        }
    }

    // Método para selecionar um canal pelo número
    public void SelecionarCanal(int numeroDoCanal)
    {
        if (numeroDoCanal >= CanalMinimo && numeroDoCanal <= CanalMaximo)
        {
            Canal = numeroDoCanal; // Atualiza para o número selecionado, caso seja válido
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(numeroDoCanal), "O número do canal deve estar entre 1 e 999.");
        }
    }
}