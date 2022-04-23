﻿using SushiBarBusinessLogic.OfficePackage.HelperEnums;
using SushiBarBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;

namespace SushiBarBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdf
    {
        public void CreateDoc(PdfInfo info)
        {
            CreatePdf();
            CreateParagraph(new PdfParagraph
            {
                Text = info.Title,
                Style = "NormalTitle"
            });
            CreateParagraph(new PdfParagraph
            {
                Text = $"с { info.DateFrom.ToShortDateString() } по " +
                $"{  info.DateTo.ToShortDateString() }", Style = "Normal" 
            });
            CreateTable(new List<string> { "3cm", "6cm", "3cm", "2cm", "3cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Дата заказа", "Изделие", "Количество", "Сумма", "Статус" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            foreach (var order in info.Orders)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { order.DateCreate.ToShortDateString(),
                    order.DishName, order.Count.ToString(), order.Sum.ToString(), order.Status.ToString()
},
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            SavePdf(info.FileName);
        }

        public void CreateDocOrdersDate(PdfOrdersDateInfo info)
        {
            CreatePdf();
            CreateParagraph(new PdfParagraph
            {
                Text = info.Title,
                Style = "NormalTitle"
            });
            CreateParagraph(new PdfParagraph
            {
                Text = $"Заказы по всем датам",
                Style = "Normal"
            });
            CreateTable(new List<string> { "8cm", "6cm", "3cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Дата заказов", "Количество заказов", "Сумма" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            foreach (var order in info.OrdersDate)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { order.DateCreate.ToShortDateString(), order.Count.ToString(), order.Sum.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            SavePdf(info.FileName);
        }

        /// <summary>
        /// Создание doc-файла
        /// </summary>
        protected abstract void CreatePdf();
        /// <summary>
        /// Создание параграфа с текстом
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateParagraph(PdfParagraph paragraph);
        /// <summary>
        /// Создание таблицы
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateTable(List<string> columns);
        /// <summary>
        /// Создание и заполнение строки
        /// </summary>
        /// <param name="rowParameters"></param>
        protected abstract void CreateRow(PdfRowParameters rowParameters);
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="fileName"></param>
        protected abstract void SavePdf(string fileName);
    }
}

