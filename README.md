# GeojsonToKml
geojson convert to kml and kml to geojson ,kml to csv csv to geojson

基于C#开发的geojson、kml、csv互转换工具。


**界面**


## code readme

### kml <-> geojson

kml和geojson的互转换是本工具的核心功能，涉及的代码也是最复杂的，
主函数是geojsonToKml(bool isLight)和kmlToGeojson（bool isLight），
geojsonToKml该函数在读入文件通过Json库构建了JObject后根据isLight的值分为了两个部分：
轻量转换和全量转换，轻量转换是读取了核心的坐标数据后只保留了基本的属性，因为geojson实际上额外属性并不多，
一般就是name、marker-color、marker-symbol等，可以遍历properties获取，因此这部分轻量和全量基本没有区别。
遍历json的节点时，通过for循环遍历，逐个判断是点还是线还是面还是其他的，这部分的代码框架：

```
                List<JToken> jlst = jfts.ToList<JToken>();

                for (int i = 0; i < jlst.Count; i++) {
                    // prop的处理
                    string jt1 = (string)jlst[i]["geometry"]["type"];
                    if (jt1 == "Point") {
                    }
                    else if (jt1 == "MultiPoint") {
                        }
                    }
                    else if (jt1 == "LineString") {
                        xdoc.AppendChild(xpmk);
                    }
                    else if (jt1 == "MultiLineString") {
                        Array arr1 = jlst[i]["geometry"]["coordinates"].ToArray(); //对应三维数组
                        XmlElement mlgeo = xmlVer.CreateElement("MultiGeometry");
                        for (int j = 0; j < arr1.Length; j++) {
                        }
                        xpmk1.AppendChild(mlgeo);
                        xdoc.AppendChild(xpmk);
                    }
                    else if (jt1 == "Polygon") {
                        Array arr1 = jlst[i]["geometry"]["coordinates"].ToArray();//三维数组
                    }
                    else if (jt1 == "MultiPolygon") {
                    }
                    else if (jt1 == "GeometryCollection") {
                    }
                }

```

Geojson转Kml的过程中，是用kml进行中间格式保存一些数据，再构建xml树形成完备规范的kml文件。
之前试过用jsn作为中间格式，策略是geojson->json->kml，但是由于字典不能有重复的名字，会出现很多问题，
所以最后改为了kml作为桥梁。实现过程中用到的库有Newtonsoft.Json和System.Xml；Newtonsoft.Json通过在官网下载通过dll进行引用。
主要是通过这两个库提供的XmlDocument和JObject进行数据的表达，省去了自己写对应的数据结构的精力和时间。


### geojson <-> csv

相对于geojson和kml之间的互转换，因为csv只考虑点（Point）数据，所以情况比较简单，也比较容易实现。
应用上面geojson与kml互转换的解析思路，写了函数geojsonTo
CsvPoi ()，在for循环里只需要对点数据进行解析，并且不需要考虑properties里面的各种属性，只关注坐标数据，
定位到坐标数据后装入Array，poiArr as Array，然后调用coordPoint(poiArr)将数组转为字符串，
调用StreamReader的WriteLine写入csv文件。生成文件的编码为UTF-8。
Csv数据转geojson数据相对还复杂一些，目前采用的是全部读入csv数据流，然后转对字符串用Split切分，
对切分的每条数据调用stringPoiToDList转出数组，写入json里，再保存为文件。
当csv文件包含的点数非常多的情况下，这种可能会效率低，占用内存高，因此后期会引入内存监控，
在数据量很大的情况下对csv进行分段读取，处理完一部分csv数据之后再处理下一部分。

###  csv <-> kml

kml与csv的互相转换的思路和geojson与csv互转换的思路一致，对读入的xml数据定位到Point标签的位置
（不包括MultiGeometry里的点，因为MultiGeometry和Point是在同一个层级的标签），获取其子节点
，然后写入为csv由于Point标签里的coordinates内的数据就是字符串（不像geojson解析出来是数组类型），
直接将该字符串去除首尾可能有的空格之后写入csv文件。csv转kml是将读取的csv行数据构建为xml树，然后格式化为kml数据，再保存为kml数据文件。








### Extra Material
- [geojson.io](http://geojson.io/#map=2/20.0/0.0)


#### to do
- [x] 完善GeometryCollection和FeatureCollection的区别
- [ ] 增加对shp的支持

