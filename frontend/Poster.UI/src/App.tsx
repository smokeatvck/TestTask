import { Provider } from "react-redux";
import "./App.css";
import PostPage from "./pages/PostPage";
import { store } from "./store/postStore";

function App() {
  return (
    <Provider store={store}>
      <PostPage />
    </Provider>
  );
}

export default App;
