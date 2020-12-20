﻿using ConsoleEngine.Maths;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEngine.DisplaySystem
{
    public class ScreenLayerOrder
    {
        #region Fields
        private readonly Pool<ScreenLayer> _layerPool = new Pool<ScreenLayer>();
        private readonly LinkedList<ScreenLayer> _layers = new LinkedList<ScreenLayer>();
        #endregion

        #region Properties
        public IReadOnlyCollection<ScreenLayer> Layers => _layers;

        public IEnumerable<Vector2Int> AllPoints
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region Methods
        public ScreenLayer InitNewLayer(IGraphicObject graphicObject)
        {
            var layer = _layerPool.Extract();
            layer.Init(graphicObject);
            return layer;
        }

        public bool Contains(IGraphicObject graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                    return true;
            }

            return false;
        }

        public ScreenLayer FindLayer(IGraphicObject graphicObject)
        {
            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                    return layer;
            }

            return null;
        }

        public LinkedListNode<ScreenLayer> ExtractLayerNode(IGraphicObject graphicObject)
        {
            LinkedListNode<ScreenLayer> result = null;

            foreach (var layer in _layers)
            {
                if (layer.Contains(graphicObject))
                {
                    result = _layers.Find(layer);
                    _layers.Remove(result);
                    break;
                }
            }

            return result;
        }

        public void AddToTop(ScreenLayer layer) => _layers.AddFirst(layer);
        public void AddToTop(LinkedListNode<ScreenLayer> layerNode) => _layers.AddFirst(layerNode);

        public IEnumerable<ScreenLayer> SelectLayersAbove(IGraphicObject graphicObject) =>
                                            _layers.TakeWhile(layer => layer.Contains(graphicObject) == false);

        public IEnumerable<ScreenLayer> SelectLayersBelow(IGraphicObject graphicObject) =>
                                            _layers.SkipWhile(layer => layer.Contains(graphicObject)).Skip(1);

        public void Clear(ScreenLayer layer)
        {
            _layers.Remove(layer);
            layer.Clear();
            _layerPool.Place(layer);
        }

        public void Clear()
        {
            foreach (var layer in _layers)
            {
                layer.Clear();
                _layerPool.Place(layer);
            }

            _layers.Clear();
        }
        #endregion
    }
}
