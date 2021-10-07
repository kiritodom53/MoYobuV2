using System;
using System.Collections.Generic;
using System.IO;

namespace AuxiliaryAlgorithms
{
    internal class Program
    {
        private static string _path =
            @"C:\Users\dom53ntb\Documents\_workspace\cSharp\MoYobuV2\AuxiliaryAlgorithms\Output";

        private static readonly List<string> _tags = new List<string>
        {
            "Action",
            "Adaptation",
            "Adventure",
            "Aliens",
            "Animals",
            "Anthology",
            "Award Winning",
            "Boy's Love",
            "Comedy",
            "Cooking",
            "Crime",
            "Crossdressing",
            "Delinquents",
            "Demons",
            "Doujinshi",
            "Drama",
            "Fan Colored",
            "Fantasy",
            "4-Koma",
            "Full Color",
            "Genderswap",
            "Ghosts",
            "Girl's Love",
            "Gore",
            "Gyaru",
            "Harem",
            "Historical",
            "Horror",
            "Incest",
            "Isekai",
            "Loli",
            "Long Strip",
            "Mafia",
            "Magic",
            "Magical Girls",
            "Martial Arts",
            "Mecha",
            "Medical",
            "Military",
            "Monster Girls",
            "Monsters",
            "Music",
            "Mystery",
            "Ninja",
            "Office Workers",
            "Official Colored",
            "Oneshot",
            "Philosophical",
            "Police",
            "Post-Apocalyptic",
            "Psychological",
            "Reincarnation",
            "Reverse Harem",
            "Romance",
            "Samurai",
            "School Life",
            "Sci-Fi",
            "Sexual Violence",
            "Shota",
            "Slice of Life",
            "Sports",
            "Superhero",
            "Supernatural",
            "Survival",
            "Thriller",
            "Time Travel",
            "Tragedy",
            "Traditional Games",
            "User Created",
            "Vampires",
            "Video Games",
            "Villainess",
            "Virtual Reality",
            "Web Comic",
            "Wuxia",
            "Zombies"
        };

        public string TagAction { get; set; }

        public static void Main(string[] args)
        {
            // GenerateTagCheckBox();
            // GenerateTagFiledsAndProperties();
            // Console.WriteLine(nameof(TagAction).Substring(3));

            int[] t = new[] { 1, 2, 3 };
            Console.WriteLine(t.Length);
        }

        private static void GenerateTagFiledsAndProperties()
        {
            var file = Path.Combine(_path, $"tags_fields_properties_{DateTime.Today:yyyyMMddHHmmss}.txt");
            File.Create(file).Dispose();

            foreach (string item in _tags)
            {
                string pretyItem = item.Replace(" ", "").Replace("'", "").Replace("-", "");
                File.AppendAllText(file,
                    $"private bool? _tag{pretyItem} = false;\n");
            }
            File.AppendAllText(file, "\n\n\n\n\n");

            foreach (string item in _tags)
            {
                string pretyItem = item.Replace(" ", "").Replace("'", "").Replace("-", "");
                File.AppendAllText(file,
                    $"public bool? Tag{pretyItem}\n{{\nget {{ return _tag{pretyItem}; }}\nset => SetProperty(ref _tag{pretyItem}, value,\nnameof(Tag{pretyItem}),\n() => {{ Filter.Tag{pretyItem} = value; }});\n}}\n\n");
            }
            
            File.AppendAllText(file, "\n\n\nMdMangaFilter.cs\n\n\n");
            File.AppendAllText(file, "\n\n\nProperties\n\n\n");
            
            foreach (string item in _tags)
            {
                string pretyItem = item.Replace(" ", "").Replace("'", "").Replace("-", "");
                File.AppendAllText(file,
                    $"public bool? Tag{pretyItem} {{ get; set; }} = false;\n");
            }
            
            File.AppendAllText(file, "\n\n\nSetters\n\n\n");
            
            foreach (string item in _tags)
            {
                string pretyItem = item.Replace(" ", "").Replace("'", "").Replace("-", "");
                File.AppendAllText(file,
                    $"public MdMangaFilter SetTag{pretyItem}(bool? value = true)\n{{\nTag{pretyItem} = value;\nreturn this;\n}}\n\n");
            }
            File.AppendAllText(file, "\n\n\nBuild\n\n\n");
            
            foreach (string item in _tags)
            {
                string pretyItem = item.Replace(" ", "").Replace("'", "").Replace("-", "");
                File.AppendAllText(file,
                    $"\nif (Tag{pretyItem} == true)\n_parametersParams.Add(\"includedTags[]=\", Helper.ConvertTagToUuid(\"{pretyItem}\"));\nelse if (TagAction == null)\n_parametersParams.Add(\"excludedTags[]=\", Helper.ConvertTagToUuid(\"{pretyItem}\"));\n");
            }
        }

        private static void GenerateTagCheckBox()
        {
            var file = Path.Combine(_path, $"tags_check-boxes_{DateTime.Today:yyyyMMddHHmmss}.txt");
            File.Create(file).Dispose();

            foreach (string item in _tags)
            {
                File.AppendAllText(file,
                    $"<buttons:SfCheckBox x:Name=\"CbTag{item.Replace(" ", "").Replace("'", "").Replace("-", "")}\" Text=\"{item}\"\nIsThreeState=\"True\"\nIsChecked=\"{{Binding Tag{item.Replace(" ", "").Replace("'", "").Replace("-", "")}, Mode=TwoWay}}\"\nFontSize=\"16\"\nTextColor=\"White\"\nMargin=\"0,5,0,0\" />\n");
            }
        }
        
    }
    
    public static class StringExtensions
    {
        public static string FirstCharToLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }
    }
}