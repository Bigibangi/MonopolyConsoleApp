using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model {

    public abstract class BaseContainer {
        protected uint _id;
        protected float _depth;
        protected float _width;
        protected float _height;
        protected float _weight;

        protected BaseContainer() {
        }

        protected BaseContainer(float depth, float width, float height, float weight) {
            _depth = depth;
            _width = width;
            _height = height;
            _weight = weight;
        }

        [Required]
        public uint Id => _id;

        [Required]
        public float Depth { get { return _depth; } set { _depth = value; } }

        [Required]
        public float Width { get { return _width; } set { _width = value; } }

        [Required]
        public float Height => _height;
    }
}