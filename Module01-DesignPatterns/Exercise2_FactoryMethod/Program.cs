using System;

namespace DesignPatterns.FactoryMethod
{
    // 1. The Product Interface
    public interface INotification
    {
        void Send(string message);
    }

    // 2. Concrete Products
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[EMAIL SENT]: {message}");
        }
    }

    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[SMS SENT]: {message}");
        }
    }

    // 3. The Creator (Factory)
    public abstract class NotificationFactory
    {
        // The Factory Method
        public abstract INotification CreateNotification();

        public void Deliver(string message)
        {
            var notification = CreateNotification();
            notification.Send(message);
        }
    }

    // 4. Concrete Creators
    public class EmailFactory : NotificationFactory
    {
        public override INotification CreateNotification() => new EmailNotification();
    }

    public class SmsFactory : NotificationFactory
    {
        public override INotification CreateNotification() => new SmsNotification();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Executing Factory Method Pattern ---");

            // Using the Email Factory
            NotificationFactory emailFactory = new EmailFactory();
            emailFactory.Deliver("Welcome to the Deep Skilling program!");

            // Using the SMS Factory
            NotificationFactory smsFactory = new SmsFactory();
            smsFactory.Deliver("Your OTP is 492011.");
        }
    }
}