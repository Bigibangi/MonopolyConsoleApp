namespace Model {

    public interface IBaseContainerFactory<T> where T : BaseContainer {

        public abstract T CreateContaner(float a, float b, float c, float w = 30, DateOnly date = default);
    }
}