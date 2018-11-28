﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using DAL.Contexts;
using Interfaces_UI_BLL;
using MDL;

namespace DAL
{
    public class ArticleRepository : IArticleRepository
    {
        IArticleContext _context;

        public ArticleRepository(IArticleContext context)
        {
            _context = context;
        }

        public List<Article> GetAllArticles()
        {
            return _context.GetAllArticles();
        }

        public Article AddArticle(Article article)
        {
            return _context.AddArticle(article);
        }

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            return _context.AddFile(file, ArticleId, Path);
        }

        public Category AddCategoryToArticle(int id, string CategoryName)
        {
            return _context.AddCategoryToArticle(id, CategoryName);
        }

        public Article GetCurrentArticle(int articleId)
        {
            return _context.GetCurrentArticle(articleId);
        }

        public Article EditArticle(Article EditedArticle)
        {
            return _context.EditArticle(EditedArticle);
        }

        public Article DeleteArticle(int articleId)
        {
            return _context.DeleteArticle(articleId);
        }

        public FileModel DeleteFile(int ArticleID, int FileID)
        {
            return _context.DeleteFile(ArticleID, FileID);
        }

        public FileModel GetCurrentFile(int ArticleID, string File)
        {
            return _context.GetCurrentFile(ArticleID, File);
        }

    }
}
