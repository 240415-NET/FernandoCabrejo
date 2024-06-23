import React from 'react'

function Events() {

  const events = () => {
    alert("Great Clicking!");
    }
  return (
<div>
<button onClick={events}>Click here!!</button></div>
  )
}

export default Events