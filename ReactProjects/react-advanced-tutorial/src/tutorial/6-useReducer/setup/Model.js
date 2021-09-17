import React, { useEffect } from "react";

const Model = ({ modelContent, closeModel }) => {
  useEffect(() => {
    setTimeout(() => {
      closeModel();
    }, 3000);
  });

  return (
    <div className="modal">
      <p>{modelContent}</p>
    </div>
  );
};

export default Model;
