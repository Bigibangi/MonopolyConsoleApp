namespace Model {

    public class PalleteFactory<T> : IBaseContainerFactory<T> where T : BaseContainer {

        public T CreateContaner(float a, float b, float c, float w = 30, DateOnly date = default) {
            if (a <= 0 || b <= 0 || c <= 0 || w <= 0) {
                throw new Exception("Parametres must be positive!");
            }
            return (T) (new Pallete(a, b, c, w) as BaseContainer);
        }
    }
}