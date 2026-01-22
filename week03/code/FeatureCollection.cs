public class FeatureCollection
{
    public Feature[] features { get; set; }  // notice lowercase 'features'
}
public class Feature
{
    public Properties properties { get; set; }  // lowercase 'properties'
}
public class Properties
{
    public string place { get; set; }         // lowercase 'place'
    public double mag { get; set; }           // lowercase 'mag'
}
