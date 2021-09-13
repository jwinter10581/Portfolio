import React from "react";
import ReactDom from "react-dom";
import "./index.css";

const books = [
  {
    id: 1,
    img: "https://images-na.ssl-images-amazon.com/images/I/71KilybDOoL._AC_UL200_SR200,200_.jpg",
    title: "The Very Hungry Caterpillar",
    author: "Eric Carle",
  },
  {
    id: 2,
    img: "https://images-na.ssl-images-amazon.com/images/I/91m4x8jBBzS._AC_UL200_SR200,200_.jpg",
    title: "An Unapologetic Cookbook",
    author: "Joshua Weissman",
  },
  {
    id: 3,
    img: "https://images-na.ssl-images-amazon.com/images/I/91O%2B9NHn0uL._AC_UL200_SR200,200_.jpg",
    title: "The Stay-at-Home Chef Slow Cooker Cookbook",
    author: "Rachel Farnsworth",
  },
];

function BookList() {
  return (
    <section className="bookList">
      {books.map((book) => {
        return <Book key={book.id} {...book}></Book>;
      })}
    </section>
  );
}

const Book = ({ img, title, author }) => {
  const clickHandler = (e) => {
    console.log(e);
    console.log(e.target);
    alert("hello world");
  };

  const complexExample = (author) => {
    console.log(author);
  };

  return (
    <article
      className="book"
      onMouseOver={() => {
        console.log(title);
      }}
    >
      <img src={img}></img>
      <h1 onClick={() => console.log(title)}>{title}</h1>
      <h4>{author}</h4>
      <button type="button" onClick={clickHandler}>
        Reference Example
      </button>
      <button type="button" onClick={() => complexExample(author)}>
        More Complex Example
      </button>
    </article>
  );
};

ReactDom.render(<BookList />, document.getElementById("root"));
