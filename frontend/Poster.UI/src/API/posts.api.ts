import axios from "axios";

/**
 * Модель поста
 */
export interface IPost {
  id: number;
  title: string;
  body: string;
  isRead: boolean;
}

/**
 * Получить посты
 * @param limit Максимальное количество записей
 * @param lastId Идентификатор последней записей.
 * @returns Массив постов
 */
export const fetchPosts = async (
  limit: number,
  lastId: number
): Promise<IPost[]> => {
  try {
    const url = `${
      import.meta.env.VITE_POSTS_SERVER
    }/api/posts/get?limit=${limit}&lastId=${lastId}`;

    const response = await axios.get(url);

    return response.data;
  } catch {
    return [];
  }
};

/**
 * Изменить пост
 * @param post Модель поста
 * @returns true/false
 */
export const editPost = async (post: IPost): Promise<boolean> => {
  try {
    const url = `${import.meta.env.VITE_POSTS_SERVER}/api/posts/edit`;

    const response = await axios.put(url, post);
    return response.data;
  } catch {
    return false;
  }
};
