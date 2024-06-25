import React from "react";

// functional component
function Events(){

  const events = () => {
    alert("Great Form!");
  }
   return(
  <div>
  <button onClick={events}>Click here!!</button>
</div>
    )
}

export default Events