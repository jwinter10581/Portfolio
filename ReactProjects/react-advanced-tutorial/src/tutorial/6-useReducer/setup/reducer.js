export const reducer = (state, action) => {
  if (action.type === "ADD_ITEM") {
    const newPeople = [...state.people, action.payload];
    return {
      ...state,
      people: newPeople,
      isModelOpen: true,
      modelContent: "item added",
    };
  }
  if (action.type === "NO_VALUE") {
    return { ...state, isModelOpen: true, modelContent: "Please enter value" };
  }
  if (action.type === "CLOSE_MODEL") {
    return { ...state, isModelOpen: false };
  }
  if (action.type === "REMOVE_ITEM") {
    const newPeople = state.people.filter(
      (person) => person.id !== action.payload
    );
    return { ...state, people: newPeople };
  }
};
