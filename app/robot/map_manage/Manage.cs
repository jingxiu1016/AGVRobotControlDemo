using System.Text;
using System.Xml.Serialization;
using BootstrapBlazor.Components;
using Console = System.Console;
using System.IO;
using Microsoft.AspNetCore.Components.Forms;

namespace MauiApp3.app.robot.map_manage;

public class Manage
{
    public IEnumerable<SelectedItem> Maps { get; set; }
    public Map CurrentMap { get; set; }
    // 读取map文件夹下的地图文件，并将xml信息解析到地图信息对应的属性中去。
    public void LoadMap(string filepath)
    {
        try
        {
            FileStream fs = File.Open(filepath, FileMode.Open);
            using (StreamReader sr = new StreamReader(fs,Encoding.UTF8))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Map));
                CurrentMap = (Map)xs.Deserialize(sr);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Manage()
    {
        Maps = ScanMaps();
    }

    // 文件扫描，选择地图文件，只检测xml
    public IEnumerable<SelectedItem> ScanMaps()
    {
        var infos = new List<SelectedItem>();
        try
        {
            string rootPath = AppContext.BaseDirectory;
            string[] list = Directory.GetFiles(@"F:\workspace\c#\MauiApp3\app/robot/map", "*.xml");
            foreach (var item in list)
            {
                var filename = System.IO.Path.GetFileName(item);
                var temp = new SelectedItem(text:filename,value:item);
                infos.Add(temp);
            }
            LoadMap(list[0]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return infos;
    }

    public async Task<bool> SaveMap(IBrowserFile file)
    {
        var status = false;
        var filename = file.Name;
        if (filename != null)
        {
            var targetPath = System.IO.Path.Combine(@"F:\workspace\c#\MauiApp3\app\robot\map\", filename);
            using (var stream = new FileStream(targetPath,FileMode.Create))
            {
                try
                {
                    // await file.St().CopyToAsync(stream);
                    await file.OpenReadStream().CopyToAsync(stream);
                    status = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    status = false;
                    throw e;
                }
            }
        }
        return status;
    }
}