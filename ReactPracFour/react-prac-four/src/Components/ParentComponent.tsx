import React from 'react'
import ChildComponent from './ChildComponent';

function ParentComponent(){

    return(
        <>
        <ChildComponent data="something" data1="something else"/>
        </>
    )
}

export default ParentComponent