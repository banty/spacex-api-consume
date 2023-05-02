import { useQuery } from '@tanstack/react-query'
import { Launches } from '../services/api';
import { useSelector } from 'react-redux';
import { RootState } from '../app/store';

function useSpecificLaunches(id:string|undefined) {
  const {api} =useSelector ((state:RootState)=>({...state.launcher}));

    const {isLoading,data,error,isFetching}=useQuery({
      queryKey:["singleLaunch",id],
      queryFn: ()=>Launches.getSingleLaunch(api,id)
    });
  return {isLoading,data,error,isFetching};
}

export default useSpecificLaunches