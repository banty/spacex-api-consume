

export  const getUrl=  (api_type:string)=>   
(api_type === 'remote') ? "https://api.spacexdata.com/v3/launches":
"http://localhost:5028/api/Launch";
                                               
    
   
