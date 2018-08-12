namespace StoreOfBuild.Domain.Products
{
    public class DomainException : System.Exception
    {
        public DomainException(string error) : base(error){

        }

        public static void When(bool hasError, string error){
            if(!hasError){
                throw new DomainException(error);
            }
        }
    }
}