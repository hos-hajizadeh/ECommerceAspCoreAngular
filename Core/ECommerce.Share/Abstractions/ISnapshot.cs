namespace ECommerce.Share.Abstractions;

public interface ISnapshot<out TSnapshot>
{
    TSnapshot TakeSnapshot();
}