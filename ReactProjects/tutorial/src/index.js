import React from "react";
import ReactDom from "react-dom";

function BookList() {
  return (
    <section>
      <Book />
    </section>
  );
}

const Book = () => {
  return (
    <article>
      <Image></Image>
      <Title></Title>
      <Author />
    </article>
  );
};

const Image = () => (
  <img src="https://images-na.ssl-images-amazon.com/images/I/71KilybDOoL._AC_UL200_SR200,200_.jpg"></img>
);

const Title = () => <h1>The Very Hungry Caterpillar</h1>;
const Author = () => <p>Eric Carle</p>;

ReactDom.render(<BookList />, document.getElementById("root"));
