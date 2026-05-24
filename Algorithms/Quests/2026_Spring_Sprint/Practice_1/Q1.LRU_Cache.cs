// Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.
// Implement the LRUCache class:
//     LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
//     int get(int key) Return the value of the key if the key exists, otherwise return -1.
//     void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.

// The functions get and put must each run in O(1) average time complexity.

// Example 1:
// Input
// ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
// [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
// Output
// [null, null, null, 1, null, -1, null, -1, 3, 4]

// Explanation
// LRUCache lRUCache = new LRUCache(2);
// lRUCache.put(1, 1); // cache is {1=1}
// lRUCache.put(2, 2); // cache is {1=1, 2=2}
// lRUCache.get(1);    // return 1
// lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
// lRUCache.get(2);    // returns -1 (not found)
// lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
// lRUCache.get(1);    // return -1 (not found)
// lRUCache.get(3);    // return 3
// lRUCache.get(4);    // return 4

// Constraints:
//     1 <= capacity <= 3000
//     0 <= key <= 10^4
//     0 <= value <= 10^5
//     At most 2 * 10^5 calls will be made to get and put.


public class LRUCache {
    // Внутренний класс для узла двусвязного списка
    private class Node {
        public int Key;
        public int Value;
        public Node Prev;
        public Node Next;
        
        public Node(int key, int value) {
            Key = key;
            Value = value;
        }
    }

    private readonly int _capacity;
    private readonly Dictionary<int, Node> _cache;
    
    // Фиктивные (dummy) узлы для удобной работы с границами списка
    private readonly Node _head;
    private readonly Node _tail;

    public LRUCache(int capacity) {
        _capacity = capacity;
        _cache = new Dictionary<int, Node>(capacity);
        
        // Инициализируем заглушки головы и хвоста
        _head = new Node(0, 0);
        _tail = new Node(0, 0);
        _head.Next = _tail;
        _tail.Prev = _head;
    }

    public int Get(int key) {
        if (!_cache.TryGetValue(key, out Node node)) {
            return -1;
        }
        
        // Раз элемент считали, обновляем его позицию (двигаем в начало)
        MoveToHead(node);
        return node.Value;
    }

    public void Put(int key, int value) {
        if (_cache.TryGetValue(key, out Node node)) {
            // Если ключ уже есть, обновляем значение и двигаем в начало
            node.Value = value;
            MoveToHead(node);
        } else {
            // Если ключа нет, создаем новый узел
            Node newNode = new Node(key, value);
            _cache[key] = newNode;
            AddToHead(newNode);

            // Если превысили лимит, удаляем самый старый элемент из хвоста
            if (_cache.Count > _capacity) {
                Node lruNode = _tail.Prev; // Элемент перед заглушкой хвоста
                RemoveNode(lruNode);
                _cache.Remove(lruNode.Key);
            }
        }
    }

    // --- Вспомогательные методы для работы со списком ---

    // Добавление узла сразу после фиктивной головы
    private void AddToHead(Node node) {
        node.Prev = _head;
        node.Next = _head.Next;
        
        _head.Next.Prev = node;
        _head.Next = node;
    }

    // Удаление связей узла из списка
    private void RemoveNode(Node node) {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }

    // Перемещение узла в начало (считай: удалили из середины и вставили в начало)
    private void MoveToHead(Node node) {
        RemoveNode(node);
        AddToHead(node);
    }
}