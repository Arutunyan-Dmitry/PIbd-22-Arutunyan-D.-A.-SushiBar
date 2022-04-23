using SushiBarBusinessLogic.OfficePackage.HelperEnums;
using SushiBarBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;
using System;

namespace SushiBarBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info.FileName);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new
                WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            foreach (var dish in info.Dishes)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> {
                    (dish.DishName + "      ", new WordTextProperties { Size = "24", Bold = true, }),
                    (Convert.ToInt32(dish.Price).ToString() + "р", new WordTextProperties {
                        Size = "24" }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord();
        }
        public void CreateTableDoc(WordStorageFacilityInfo info)
        {
            CreateWord(info.FileName);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> {
                (info.Title, new WordTextProperties { Bold = true, Size = "24", })},
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            CreateTable(new List<string>() { "Название", "ФИО ответственного", "Дата создания" });
            foreach (var storageFacility in info.StorageFacilities)
            {
                CreateRow(new List<string>() {
                    storageFacility.Name,
                    storageFacility.OwnerFLM,
                    storageFacility.DateCreate.ToString()
                });
            }
            SaveWord();
        }
        /// <summary>
        /// Создание doc-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreateWord(string info);
        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateParagraph(WordParagraph paragraph);
        /// <summary>
        /// Создание заголовка таблицы с текстом
        /// </summary>
        /// <param name="tableHeader"></param>
        protected abstract void CreateTable(List<string> tableHeader);
        /// <summary>
        /// Создание строки таблицы с текстом
        /// </summary>
        /// <param name="tableRow"></param>
        protected abstract void CreateRow(List<string> tableRow);
        /// <summary>
        /// Сохранение файла
        /// </summary>
        protected abstract void SaveWord();
    }
}
