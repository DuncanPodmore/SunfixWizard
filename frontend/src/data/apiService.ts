const baseUrl = 'http://localhost:5033';

const handleResponse = async <T>(response: Response): Promise<T | null> => {
    if (!response.ok) {
        const errorMessage = await response.text();
        console.error('Error:', errorMessage);
        throw new Error(`HTTP Error ${response.status}: ${errorMessage}`);
    }
    return await response.json() as T;
};

export const get = async <T>(endpoint: string): Promise<T | null> => {
    try {
        const response = await fetch(`${baseUrl}/${endpoint}`);
        return await handleResponse<T>(response);
    } catch (error) {
        console.error('Error fetching data:', error);
        return null;
    }
};

export const getById = async <T>(endpoint: string, id: number): Promise<T | null> => {
    try {
        const response = await fetch(`${baseUrl}/${endpoint}/${id}`);
        return await handleResponse<T>(response);
    } catch (error) {
        console.error(`Error fetching data by ID (${id}):`, error);
        return null;
    }
};

export const post = async <T>(endpoint: string, data: any): Promise<T | null> => {
    try {
        const response = await fetch(`${baseUrl}/${endpoint}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return await handleResponse<T>(response);
    } catch (error) {
        console.error('Error posting data:', error);
        return null;
    }
};

export const put = async <T>(endpoint: string, id: number, data: T): Promise<T | null> => {
    try {
        const response = await fetch(`${baseUrl}/${endpoint}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        return await handleResponse<T>(response);
    } catch (error) {
        console.error('Error updating data:', error);
        return null;
    }
};

export const del = async <T>(endpoint: string, id: number): Promise<T | null> => {
    try {
        const response = await fetch(`${baseUrl}/${endpoint}/${id}`, {
            method: 'DELETE',
        });
        return await handleResponse<T>(response);
    } catch (error) {
        console.error('Error deleting data:', error);
        return null;
    }
};
