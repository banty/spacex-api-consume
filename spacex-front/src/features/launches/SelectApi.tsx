import { Radio, RadioChangeEvent } from 'antd'
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import {  localApi, remoteApi, selectLauncher } from './LaunchSlice';

function SelectApi() {
    const dispatch= useAppDispatch();
    const {api} = useAppSelector(selectLauncher);
    const handleSizeChange = (e: RadioChangeEvent) => {
          dispatch(e.target.value==='local'? localApi():remoteApi());
         console.log(e.target.value);
      };
  return (
    <div className='default-pad'>
      <Radio.Group value={api}      buttonStyle='solid'   onChange={handleSizeChange}>
        <Radio.Button type={api==='remote'?'primary':'success'} value="remote">Remote SpaceX Api</Radio.Button>
        <Radio.Button type={api==='local'?'primary':'none'} value="local">Local Api</Radio.Button>

      </Radio.Group>
    </div>
    
  )
}

export default SelectApi