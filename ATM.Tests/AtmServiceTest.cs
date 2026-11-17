namespace ATM.ATM.Tests;

using Xunit;

public class AtmServiceTest
{

  Card card;
  AtmService atm;

  void setupService()
  {
    Account account = new Account(5000);
    card = new Card("1234-5678", "1234", account);
    atm = new AtmService(5000);
  }

  [Fact]
  public void InsertCardTest()
  {
    // setup
    Account account = new Account(5000);
    Card card = new Card("1234-5678", "1234", account);
    AtmService atm = new AtmService(5000);
    // test
    atm.InsertCard(card);
    Assert.True(atm.HasCardInserted);
  }

  [Theory]
  [InlineData("1234", true)]
  [InlineData("0123", false)]
  [InlineData("12345", false)]
  [InlineData("123", false)]
  [InlineData("01234", false)]
  public void EnterPinTest(string pin, bool expected)
  {
    // setup
    setupService();
    atm.InsertCard(card);
    // test
    bool actual = atm.EnterPin(pin);
    Assert.Equal(expected, actual);
  }

}