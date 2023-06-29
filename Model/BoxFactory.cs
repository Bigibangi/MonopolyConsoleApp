namespace Model {

    public class BoxFactory<T> : IBaseContainerFactory<T> where T : BaseContainer {

        public T CreateContaner(float a, float b, float c, float w, DateOnly date) {
            if (a <= 0 || b <= 0 || c <= 0 || w <= 0 || date <= DateOnly.MinValue) {
                throw new Exception("Parametres must be positive!");
            }
            return (T) (new Box(a, b, c, w, date) as BaseContainer);
        }
    }
}