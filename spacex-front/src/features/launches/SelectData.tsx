import { Radio, RadioChangeEvent } from 'antd'
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import {   pastData, selectLauncher, upcomingData } from './LaunchSlice';

function SelectData() {
    const dispatch= useAppDispatch();
    const {status} = useAppSelector(selectLauncher);
    const handleSizeChange = (e: RadioChangeEvent) => {
      dispatch(e.target.value==='past'? pastData():upcomingData());
         console.log(e.target.value);
      };
  return (
    <div className='default-pad'>
      <Radio.Group value={status}         optionType='default'  onChange={handleSizeChange}>
        <Radio.Button type={status==='past'?'primary':'success'} value="past">Past Launches</Radio.Button>
        <Radio.Button type={status==='upcoming'?'primary':'none'} value="upcoming">Upcoming Launches</Radio.Button>

      </Radio.Group>
    </div>
    
  )
}

export default SelectData