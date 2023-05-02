import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import launchReducer from '../features/launches/LaunchSlice';

export const store = configureStore({
  reducer: {
    launcher: launchReducer,

  },
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
