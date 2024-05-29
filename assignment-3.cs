using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public string UId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ISBN { get; set; }
    public bool IsIssued { get; set; }
}

public class Member
{
    public string UId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
}

public class Issue
{
    public string UId { get; set; }
    public string BookId { get; set; }
    public string MemberId { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
}

public class LibraryManagementSystem
{
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();
    private List<Issue> issues = new List<Issue>();

    // Book operations
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public Book GetBookByUId(string uId)
    {
        return books.FirstOrDefault(b => b.UId == uId);
    }

    public List<Book> GetBooksByTitle(string title)
    {
        return books.Where(b => b.Title == title).ToList();
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }

    public List<Book> GetAllAvailableBooks()
    {
        return books.Where(b => !b.IsIssued).ToList();
    }

    public List<Book> GetAllIssuedBooks()
    {
        return books.Where(b => b.IsIssued).ToList();
    }

    public void UpdateBook(Book book)
    {
        var existingBook = books.FirstOrDefault(b => b.UId == book.UId);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.ISBN = book.ISBN;
            existingBook.IsIssued = book.IsIssued;
        }
    }

    // Member operations
    public void AddMember(Member member)
    {
        members.Add(member);
    }

    public Member GetMemberByUId(string uId)
    {
        return members.FirstOrDefault(m => m.UId == uId);
    }

    public List<Member> GetAllMembers()
    {
        return members;
    }

    public void UpdateMember(Member member)
    {
        var existingMember = members.FirstOrDefault(m => m.UId == member.UId);
        if (existingMember != null)
        {
            existingMember.Name = member.Name;
            existingMember.DateOfBirth = member.DateOfBirth;
            existingMember.Email = member.Email;
        }
    }

    // Issue operations
    public void IssueBook(Issue issue)
    {
        issues.Add(issue);
        var book = books.FirstOrDefault(b => b.UId == issue.BookId);
        if (book != null)
            book.IsIssued = true;
    }

    public Issue GetIssueByUId(string uId)
    {
        return issues.FirstOrDefault(i => i.UId == uId);
    }

    public void UpdateIssue(Issue issue)
    {
        var existingIssue = issues.FirstOrDefault(i => i.UId == issue.UId);
        if (existingIssue != null)
        {
            existingIssue.BookId = issue.BookId;
            existingIssue.MemberId = issue.MemberId;
            existingIssue.IssueDate = issue.IssueDate;
            existingIssue.ReturnDate = issue.ReturnDate;
            existingIssue.IsReturned = issue.IsReturned;
        }
    }
}
