using exercise.main;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFilling()
    {
        Filling filling = new Filling("Bacon");

        Assert.That(filling.Variant, Is.EqualTo("Bacon"));
        Assert.That(filling.Price, Is.EqualTo(0.12));
        Assert.That(filling.SKU, Is.EqualTo("FILB"));
    }

    [Test]
    public void TestBagelConstructor()
    {
        Bagel bagel = new Bagel("Onion");

        Assert.That(bagel.Variant, Is.EqualTo("Onion"));
        Assert.That(bagel.Price, Is.EqualTo(0.49));
        Assert.That(bagel.SKU, Is.EqualTo("BGLO"));
        Assert.That(bagel.Filling, Is.EqualTo(null));
    }

    [Test]
    public void TestBagelSetFilling()
    {
        Bagel bagel = new Bagel("Onion");
        bagel.SetFilling("Bacon");

        Assert.That(bagel.Filling, Is.Not.Null);
        Assert.That(bagel.Filling.Variant, Is.EqualTo("Bacon"));
    }

    [Test]
    public void TestBasketConstructor()
    {
        Basket basket = new Basket();

        Assert.That(basket.NrItems, Is.EqualTo(0));
        Assert.That(basket.Capacity, Is.EqualTo(10));
        Assert.That(basket.Total, Is.EqualTo(0));
    }

    [Test]
    public void TestBasketAdd()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("Onion");

        basket.Add(bagel);

        Assert.That(basket.NrItems, Is.EqualTo(1));
        Assert.That(basket.Total, Is.EqualTo(0.49));
        Assert.That(basket.Bagels[0], Is.EqualTo(bagel));

        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);

        Assert.Throws<Exception>(() => basket.Add(bagel));

    }

    [Test]
    public void TestBasketRemove()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("Onion");

        basket.Add(bagel);
        basket.Remove(bagel);

        Assert.That(basket.Bagels.Count, Is.EqualTo(0));

        Assert.Throws<Exception>(() => basket.Remove(bagel));
    }

    [Test]
    public void TestBobsBagelConstructor()
    {
        BobsBagels store = new BobsBagels();

        Assert.That(store.Capacity, Is.EqualTo(10));
        Assert.That(store.Baskets.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestAddBasket()
    {
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);

        Assert.That(store.Baskets.Count, Is.EqualTo(1));
        Assert.That(store.Baskets[0], Is.EqualTo(basket));
    }

    [Test]
    public void TestRemoveBasket()
    {
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.RemoveBasket(basket);

        Assert.That(store.Baskets.Count, Is.EqualTo(0));
        Assert.Throws<Exception>(() => store.RemoveBasket(basket));
    }

    [Test]
    public void TestIncreaseCapacity() 
    {
        BobsBagels store = new BobsBagels(); 
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(10);

        Assert.That(store.Capacity, Is.EqualTo(20));
        Assert.That(basket.Capacity, Is.EqualTo(20));
    }

    [Test]
    public void TestCoffeeConstructor()
    {
        Coffee coffee = new Coffee("White");

        Assert.That(coffee.Variant, Is.EqualTo("White"));
        Assert.That(coffee.SKU, Is.EqualTo("COFW"));
        Assert.That(coffee.Price, Is.EqualTo(1.19));
    }

    [Test]
    public void TestAddCoffee()
    {
        Basket basket = new Basket();
        Coffee coffee = new Coffee("Black");

        basket.Add(coffee);

        Assert.That(basket.NrItems, Is.EqualTo(1));

        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);

        Assert.Throws<Exception>(() => basket.Add(coffee));

    }

    [Test]
    public void TestRemoveCoffee()
    {
        Basket basket = new Basket();
        Coffee coffee = new Coffee("Black");

        basket.Add(coffee);
        basket.Remove(coffee);

        Assert.That(basket.NrItems, Is.EqualTo(0));

        Assert.Throws<Exception>(() => basket.Remove(coffee));
    }

    [Test]
    public void TestAddNonExistantBagel()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("Chicken");

        Assert.Throws<Exception>(() => basket.Add(bagel));
    }
}