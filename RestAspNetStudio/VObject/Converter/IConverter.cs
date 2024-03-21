namespace RestAspNetStudio.VObject.Converter
{
    public interface IConverter<I, O>
    {
            public O Convert(I input);
            public List<O> Convert(List<I> input);
    }
}
