var EventSubscriber = function () {
    const subscribers = [];

    const subscribe = (event, callback) => {
        if (!subscribers[event]) subscribers[event] = []
        subscribers[event].push(callback)
    }
    const unsubscribe = (event) => {
        subscribers = subscribers.filter((observer) => observer !== event)
    }
    const notify = (event, message) => {
        if (!subscribers[event]) return
        subscribers[event].forEach((observer) => observer(message))
    }

    return {
        subscribe,
        unsubscribe,
        notify
    }
}
