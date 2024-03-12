using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TRS2004Edit;

class TuningFile
{
    byte[] data;
    string path;

    public float Unknown0;
    public float Unknown1;

    public float Gamma;
    public float Particles;

    public float GroundTextureGradient;
    public float GroundDetail;

    public float DrawDistanceGround;
    public float DrawDistanceScenery;

    public float FogGoodWeather;
    public float FogBadWeather;

    public float Train;
    public float Spline;

    public TuningFile(string path)
    {
        Load(path);
    }

    public void Data(bool write)
    {
        var view = new BinaryView(data, write);
        view._(0x00, ref Unknown0);
        view._(0x04, ref Gamma);
        view._(0x08, ref Particles);
        view._(0x0C, ref FogGoodWeather);
        view._(0x10, ref FogBadWeather);
        view._(0x14, ref GroundTextureGradient);
        view._(0x18, ref GroundDetail);
        view._(0x1c, ref DrawDistanceGround);
        view._(0x20, ref DrawDistanceScenery);
        view._(0x24, ref Train);
        view._(0x28, ref Unknown1);
        view._(0x2C, ref Spline);
    }

    public void Load(string path)
    {
        this.path = path;

        data = File.ReadAllBytes(path);

        if (data.Length != 48)
            throw new Exception();

        Data(false);
    }

    public void Save(string path = null)
    {
        if (path == null)
            path = this.path;

        Data(true);

        File.WriteAllBytes(path, data);
    }
}
