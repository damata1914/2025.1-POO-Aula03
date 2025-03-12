namespace aula_03.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Soma_Deve_Retornar_5()
    {
        int resultado = 2 + 3;

       Assert.AreEqual(5, resultado);
    }
}

public class DispositivoTestsVolume
{
    [Fact]
    public void Deve_Manter_Mudo_Ao_Tentar_Alterar_Volume()
    {
        // Arrange
        var dispositivo = new Dispositivo();
        dispositivo.SetMudo(true); // Ativar o modo "mudo"
        int volumeAnterior = dispositivo.Volume;

        // Act
        dispositivo.AlterarVolume(80); // Tentar alterar o volume enquanto está no modo "mudo"

        // Assert
        Assert.Equal(volumeAnterior, dispositivo.Volume); // O volume não deve mudar
    }

    [Fact]
    public void Deve_Alterar_Volume_Quando_Nao_Estiver_Mudo()
    {
        // Arrange
        var dispositivo = new Dispositivo();
        dispositivo.SetMudo(false); // Desativar o modo "mudo"

        // Act
        dispositivo.AlterarVolume(80);

        // Assert
        Assert.Equal(80, dispositivo.Volume); // O volume deve ser alterado
    }
}


public class DispositivoTestsCanal.
{
    [Fact]
    public void Deve_Alterar_Canal_Para_Frente()
    {
        // Arrange
        var dispositivo = new Dispositivo();

        // Act
        dispositivo.AlterarCanal(true); // Avançar para o próximo canal

        // Assert
        Assert.Equal(2, dispositivo.Canal); // O canal deve ser 2
    }

    [Fact]
    public void Deve_Alterar_Canal_Para_Tras()
    {
        // Arrange
        var dispositivo = new Dispositivo();
        dispositivo.AlterarCanal(true); // Avançar para o canal 2

        // Act
        dispositivo.AlterarCanal(false); // Voltar para o canal 1

        // Assert
        Assert.Equal(1, dispositivo.Canal); // O canal deve ser 1 novamente
    }

    [Fact]
    public void Deve_Selecionar_Canal_Pelo_Numero()
    {
        // Arrange
        var dispositivo = new Dispositivo();

        // Act
        dispositivo.SelecionarCanal(505); // Selecionar o canal 505

        // Assert
        Assert.Equal(505, dispositivo.Canal); // O canal deve ser atualizado para 505
    }

    [Fact]
    public void Deve_Lancar_Excecao_Para_Canal_Invalido()
    {
        // Arrange
        var dispositivo = new Dispositivo();

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => dispositivo.SelecionarCanal(1000)); // Canal inválido
    }
}