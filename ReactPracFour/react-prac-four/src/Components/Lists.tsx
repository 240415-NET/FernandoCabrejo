import React from 'react'

function Lists() {

const myArray = ['apple', 'banana', 'coconut', 'Chirimoya'];

const myList = myArray.map((item,index) => <p key={index}>{item}</p>)

return(
 <div>
    {myList}
</div>
  )
}

export default Lists