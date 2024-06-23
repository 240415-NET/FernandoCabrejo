import React from 'react'
import ChildComponent from './ChildComponent' ;

// parent component

function ParentComponent(){

  return(
      <>
          <ChildComponent data="something" data1="something1"/>
      </>
  )
}

export default ParentComponent