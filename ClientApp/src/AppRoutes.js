import { Counter } from "./components/Counter";
import { Users } from "./components/User";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
      path: '/User',
      element: <Users />
  }
];

export default AppRoutes;
