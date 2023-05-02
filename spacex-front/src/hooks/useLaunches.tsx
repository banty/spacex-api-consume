import { useQuery } from '@tanstack/react-query'
import { Launches } from '../services/api';
import { useSelector } from 'react-redux';
import { selectLauncher } from '../features/launches/LaunchSlice';


function useLaunches() {
   
  const {api,status} =useSelector (selectLauncher);
 

    const {isLoading,data,error,isFetching}=useQuery({
        queryKey:["launchData",api,status],
        queryFn: ()=>Launches.getLaunches(api,status),
        refetchOnWindowFocus:false,

    });
  return {isLoading,data,error,isFetching};
}

export default useLaunches