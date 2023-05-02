

export  const getUrl=  (api_type:string)=>   
(api_type === 'remote') ? process.env.REACT_APP_REMOTE_SPACEX_URL:
    process.env.REACT_APP_LOCAL_SPACEX_URL;
                                                                       
