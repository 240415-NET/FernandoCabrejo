import {useState, useEffect} from 'react'

function DataFetcher(){

// interface used to describe the shape of the api response
interface Data {
    name: string,
    value: number
}

//state variable storing the state
let [data, setData] = useState<Data | undefined>(undefined);

// async function to get the data
async function getData(){

       var xhr = new XMLHttpRequest();
    var requestUrl = "https://api.restful-api.dev/objects";
   xhr.open("GET", requestUrl, true);
   xhr.onload = function(){
   console.log(JSON.parse(xhr.response));
   };
   xhr.send();

}

// useEffect to do the call when the component loads
useEffect(() => {
    getData();
}, []);
return(
    <div>
    MyNewTest
    </div>
);
}
export default DataFetcher